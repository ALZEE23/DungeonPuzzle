VAR nilai2 = 0

-> question1

=== question1 ===
- 7. Prabu Siliwangi adalah tokoh penting dalam sejarah...
  	* [A. Tarumanegara] -> question2
  	* [B. Galuh] -> question2
	* [C. Sunda / Pajajaran] 
	~ nilai2 += 1
  	-> question2
	* [D. Banten] -> question2
    
=== question2 ===
- 8. Agama yang dianut mayoritas masyarakat Tarumanegara adalah...
  	* [A. Budha] -> question3
  	* [B. Hindu] 
	~ nilai2 += 1
	-> question3
	* [C. Islam] -> question3
	* [D. Kristen] -> question3

=== question3 ===
- 9. Kerajaan Galuh kemudian bergabung dengan Kerajaan Sunda menjadi...
  	* [A. Kerajaan Majapahit] -> END
  	* [B. Kerajaan Pajajaran] 
	~ nilai2 += 1
	-> END
	* [C. Kerajaan Mataram] -> END
	* [D. Kesultanan Cirebon] -> END


-> END
