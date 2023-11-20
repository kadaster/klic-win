# JWT-GEN

<!-- TOC -->
* [JWT-GEN](#jwt-gen)
  * [Prerequisites](#prerequisites)
  * [Description](#description)
    * [Preparing the resources](#preparing-the-resources)
    * [Create the JWKS and JWT](#create-the-jwks-and-jwt)
      * [JWKS](#jwks)
      * [JWT](#jwt)
  * [Development](#development)
  * [Disclaimer](#disclaimer)
<!-- TOC -->

## Prerequisites

- Java 8 or higher and Maven
- Private key 
- PKI Overheid certificate

## Description
This example app is published as part of the KLIC documentation. This code illustrates how a JWKS and JWT for use with the OAuth Client credentials flow can be created.

### Preparing the resources
Copy your PKIOverheid certificate to  /resources/oauth2 _(the code assumes it is named myPKICert.cer)_.

The Private Key is generated with your Certificate Signing Request (CSR).  
Place the private key in /resources/oauth2 _(the code assumes it is named oauth2-test.key)_.

### Create the JWKS and JWT

Edit variables in the JWTGenerator class:
- Set the CLIENT_ID variable, this Client ID will be used as issuer and subject in the JWT (as obtained from the OAuth client registration).
- Set the KEY_ID variable, this will be the "kid" for both the JWT and JWK key (they should match).

Run the main method in the JWTGenerator class: `mvn compile exec:java`

#### JWKS

The JWKS will be based on the provided certificate and is generated as file jwks-oauth2.txt (overwrites a previous JWKS if present).

You can use this JWKS for your client registration proces. (see https://github.com/kadaster/klic-win/blob/master/API%20management/Authenticatie_via_oauth.md#client-applicatie-aanmelden)

#### JWT

The provided private key is used to generate your JWT as file jwt-oauth2-token.txt (overwrites the previous JWT if present).

## Development

You may have to adjust the java version in the pom.xml file (default java 1.8).

Compile the application using maven: `mvn clean compile`  
To run this application do `mvn compile exec:java`  

When the application has run successfully you should see:
```text
Generated JWKS file: jwks-oauth2.txt
Generated JWT Token: jwt-oauth2-token.txt  
```

## Disclaimer

Het Kadaster stelt reguliere (technische) documentatie beschikbaar aan de netbeheerder of degene die in opdracht van hem
werkzaamheden verricht.
Er is aangegeven dat voorbeeldcode toegevoegde waarde heeft.
Het Kadaster biedt hiermee voorbeeldcode aan als hulpmiddel bij de implementatie bij Netbeheerder en/of Serviceprovider.

In geen geval is het Kadaster aansprakelijk voor schade of andere onregelmatigheden die veroorzaakt zijn of worden door
gebruik of toepassing van de voorbeeldcode door een netbeheerder of degene die in opdracht van hem werkzaamheden verricht.

Netbeheerders blijven te allen tijde verantwoordelijk.