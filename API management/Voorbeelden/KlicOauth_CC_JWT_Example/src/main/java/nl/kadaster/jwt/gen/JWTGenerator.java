package nl.kadaster.jwt.gen;

import com.nimbusds.jose.JWSAlgorithm;
import com.nimbusds.jose.jwk.JWK;
import com.nimbusds.jose.jwk.JWKSet;
import com.nimbusds.jose.jwk.KeyUse;
import com.nimbusds.jose.jwk.RSAKey;
import com.nimbusds.jose.util.Base64URL;
import io.jsonwebtoken.Jwts;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.security.MessageDigest;
import java.security.PrivateKey;
import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.cert.CertificateFactory;
import java.security.cert.X509Certificate;
import java.security.interfaces.RSAPublicKey;
import java.security.spec.InvalidKeySpecException;
import java.security.spec.PKCS8EncodedKeySpec;
import java.time.LocalDateTime;
import java.util.Base64;
import java.util.Collections;
import java.util.Date;
import java.util.UUID;

import static java.lang.String.format;
import static java.nio.file.Files.readAllBytes;
import static java.nio.file.Files.write;
import static java.nio.file.Paths.get;
import static java.security.KeyFactory.getInstance;
import static java.time.LocalDateTime.now;
import static java.time.ZoneId.systemDefault;
import static java.util.Base64.getDecoder;
import static java.util.Date.from;

public class JWTGenerator {

    /** The key ID must be the same in JWKS and JWT. TODO change me! */
    private static final String KEY_ID = "mydummykey";

    /** The client id. TODO change me! */
    private static final String CLIENT_ID = "12345678-1234-5678-abcd-1234abcd5678";

    /** Input. */
    private static final String PRIVATE_KEY_PEM_FILE = "oauth2/oauth2-test.key";
    private static final String PKI_OVERHEID_CERTIFICATE = "oauth2/myPKICert.cer";

    /** Output generated JWKS file. */
    private static final String JWKS_OAUTH2_FILE = "jwks-oauth2.txt";

    /** Output generated JWT Token file. */
    private static final String JWT_OAUTH2_TOKEN_FILE = "jwt-oauth2-token.txt";

    /** Audience Kadaster, the service the JWT itself is intended for. */
    private static final String AUDIENCE_KADASTER = "authorization.kadaster.nl:443/auth/oauth/v2/token";

    private static final String EMPTY_STRING = "";
    private static final String CARRIAGE_RETURN = "\r";
    private static final String LINEFEED_REGEX = "\\n";
    private static final String PRIVATE_KEY_PEM_HEADER = "-----BEGIN PRIVATE KEY-----";
    private static final String PRIVATE_KEY_PEM_FOOTER = "-----END PRIVATE KEY-----";


    public static void main(String[] args) {
        generateJWKSOauth2(PKI_OVERHEID_CERTIFICATE);
        generateJWTOauth2Token(PRIVATE_KEY_PEM_FILE);
    }

    /**
     * Generate oauth2 JWKS (Json Web Key Set).
     */
    public static void generateJWKSOauth2(String certificate) {
        try {
            CertificateFactory cf = CertificateFactory.getInstance("X.509");
            X509Certificate signerCert = (X509Certificate) cf.generateCertificate(readResourceAsInputstream(certificate));

            final byte[] encodedCert = Base64.getEncoder().encode(signerCert.getEncoded());
            final com.nimbusds.jose.util.Base64 base64Cert = new com.nimbusds.jose.util.Base64(new String(encodedCert));

            // Convert to JWK format
            MessageDigest sha256 = MessageDigest.getInstance("SHA-256");
            JWK jwk = new RSAKey.Builder((RSAPublicKey) signerCert.getPublicKey())
                    .keyUse(KeyUse.SIGNATURE)
                    .keyID(KEY_ID)
                    .algorithm(JWSAlgorithm.RS256)
                    .x509CertChain(Collections.singletonList(base64Cert))
                    .x509CertSHA256Thumbprint(Base64URL.encode(sha256.digest(signerCert.getEncoded())))
                    .build();

            // Create the JWKS and insert the JWK
            JWKSet jwks = new JWKSet(jwk);

            write(get(JWKS_OAUTH2_FILE), jwks.toString().getBytes());
            System.out.printf("Generated JWKS file: %s%n", JWKS_OAUTH2_FILE);

        } catch(Exception e) {
            throw new RuntimeException("Failed to generate the JWKS", e);
        }
    }

    /**
     * Generate a JWT oauth2 token.
     */
    public static void generateJWTOauth2Token(String privateKeyFile) {
        final String privateKey = readResource(privateKeyFile);
        final LocalDateTime dateTimeExpire = now().plusMonths(1);

        final Date expirationDate = from(dateTimeExpire.atZone(systemDefault()).toInstant());
        final Date notbeforedate = from(now().atZone(systemDefault()).toInstant());
        final Date issueAtTime = from(now().atZone(systemDefault()).toInstant());

        // Build the JWT
        final String jwtToken = Jwts.builder()
                .header()
                    .add("kid", KEY_ID)
                    .add("typ", "JWT")
                    .and()
                .subject(CLIENT_ID)
                .issuer(CLIENT_ID)
                .audience()
                    .add(AUDIENCE_KADASTER)
                    .and()
                .expiration(expirationDate)
                .notBefore(notbeforedate)
                .issuedAt(issueAtTime)
                .id(UUID.randomUUID().toString())
                .signWith(getPrivateKey(privateKey))
                .compact();

        try {
            write(get(JWT_OAUTH2_TOKEN_FILE), jwtToken.getBytes());
            System.out.printf("Generated JWT Token: %s%n", JWT_OAUTH2_TOKEN_FILE);
        } catch (IOException e) {
            throw new RuntimeException("Failed to save the JWT Token to a file!", e);
        }
    }

    /**
     * Create a PrivateKey object from the provided privateKeyEntry string.
     * @param privateKeyEntry private key as string in PEM format
     * @return PrivateKey object
     */
    private static PrivateKey getPrivateKey(final String privateKeyEntry) {
        final String privateKey = privateKeyEntry
                .replaceAll(LINEFEED_REGEX, EMPTY_STRING)
                .replace(PRIVATE_KEY_PEM_HEADER, EMPTY_STRING)
                .replace(PRIVATE_KEY_PEM_FOOTER, EMPTY_STRING)
                .replace(CARRIAGE_RETURN, EMPTY_STRING);
        try {
            final PKCS8EncodedKeySpec keySpecPKCS8 = new PKCS8EncodedKeySpec(getDecoder().decode(privateKey));
            final KeyFactory kf = getInstance("RSA");

            return kf.generatePrivate(keySpecPKCS8);
        } catch (final NoSuchAlgorithmException | InvalidKeySpecException exception) {
            throw new IllegalStateException(
                    format("Could not get private key due to exception: %s", exception.getMessage())
            );
        }
    }

    /**
     * Read file from the resources directory.
     * @param resourcefile path to file in resources directory
     * @return string content file
     */
    private static String readResource(final String resourcefile) {
        return new String(readResourceAsBytes(resourcefile));
    }

    /**
     * Read file from the resources directory.
     * @param resourcefile path to file in resources directory
     * @return bytearray inputstream file content
     */
    private static ByteArrayInputStream readResourceAsInputstream(final String resourcefile) {
        return new ByteArrayInputStream(readResourceAsBytes(resourcefile));
    }

    /**
     * Read file from the resources directory.
     * @param resourcefile path to file in resources directory
     * @return byte content file
     */
    private static byte[] readResourceAsBytes(final String resourcefile) {
        final URL resourceURL = JWTGenerator.class.getClassLoader().getResource(resourcefile);

        if (resourceURL == null) {
            throw new IllegalStateException(format("Could not open resource file %s!", resourcefile));
        }

        try {
            return readAllBytes(get(resourceURL.toURI()));
        } catch (URISyntaxException | IOException e) {
            throw new IllegalStateException(format("Could not open resource file %s!", resourcefile));
        }
    }

}
