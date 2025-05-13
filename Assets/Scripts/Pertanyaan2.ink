VAR nilai1 = 0

-> question1

=== question1 ===
- 4. Kerajaan Galuh berpusat di wilayah yang sekarang dikenal sebagai...
  	* [A. Sukabumi] -> question2
  	* [B. Ciamis] 
  	~ nilai1 += 1
  	-> question2
	* [C. Cirebon] -> question2
	* [D. Bandung] -> question2
    
=== question2 ===
- 5. Kerajaan Pajajaran dikenal juga dengan nama...
  	* [A. Galuh] -> question3
  	* [B. Sunda] -> question3
	* [C. Tarumanegara] -> question3
	* [D. Pakuan] 
	~ nilai1 += 1
	-> question3

=== question3 ===
- 6. Kerajaan Pajajaran runtuh akibat serangan dari...
  	* [A. Kerajaan Majapahit] -> END
  	* [B. Kerajaan Mataram] -> END
	* [C. Kesultanan Banten] 
	~ nilai1 += 1
	-> END
	* [D. Portugis] -> END


-> END
