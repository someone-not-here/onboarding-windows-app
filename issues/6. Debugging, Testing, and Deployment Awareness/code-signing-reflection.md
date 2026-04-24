## Research and Learn

### What is code signing and how does it secure applications?
Code signing is a method of attaching a digital signature to a program, file, software update, or executable. It helps to ensure the integrity and authenticity of whatever you have before installation by guaranteeing who the author is, like a wax seal on a letter.

### How does Azure Code Sign with an EV certificate work, and why is it important for maintaining trust?
**Azure Code Sign** is a secure method to digitally sign software. With it, instead of doing the signing on a developer's computer where private keys can potentially leak if compromised, the signing happens within *Azure Key Vault*, a protected cloud service serving as a Hardware Security Module. The private key never leaves the vault, ensuring greater security.

An **Extended Validation** (EV) certificate is the highest level of identity check for software publishers. This certificate requires strict verification to ensure that the company exists and is legitimate, and is issued by **Certificate Authorities** like *GlobalSign*. This ensures a greater level of trust compared to standard certificates.

### What are the broader implications of the deployment process for application security and reliability?
Code signing helps in ensuring that the software users receive is the actual, legitimate software and not a malicious version made by a bad actor. Not only that, but it also helps in ensuring developers that the libraries and other software they use to build their software are also legitimate.

## Reflection

### Reflect on why code signing is a critical step in the deployment process.
Code signing ensure both the integrity and authenticity of software. Digital signatures attached to software helps confirm that the code has not been altered since signing and that it originates from a verified publisher. If even a singly byte of the code changes after signing, the signature becomes invalid, alerting users to potential tampering.

### How does understanding the deployment process, even at a high level, impact your approach to development?
Understanding the deployment process forces you to think about security from the get-go. This improves discipline in development, helping reduce errors that would make it into production.

### What risks could arise if code signing is overlooked or improperly managed?
- If someone downloads your software over the Internet, the download could be intercepted and replaced by a malicious version of that software intending to harm the user.
- You could lose the trust of your user if something bad happens because of "your" software.
- A lack of a proper certificate may prevent your software from being published to various software repositories, who likely ask for credentials.

## Task

### Research the basics of code signing, focusing on Azure Code Sign with an EV certificate.
See *Research and Learn* above.