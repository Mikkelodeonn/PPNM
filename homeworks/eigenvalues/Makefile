out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs EVD.dll
	mcs -target:exe -out:main.exe -reference:EVD.dll main.cs

EVD.dll:EVD.cs matrix.cs vector.cs random.cs
	mcs -target:library -out:EVD.dll EVD.cs matrix.cs vector.cs random.cs

clean: 
	$(RM) *.exe *.dll [Oo]ut* 