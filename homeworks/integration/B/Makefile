Out.txt:main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe:main.cs integrate.dll
	mcs -target:exe -out:main.exe -reference:integrate.dll main.cs

integrate.dll: ../A/integrate.cs
	mcs -target:library -out:integrate.dll $^

clean: 
	$(RM) *.exe *.dll *.gpi *.png [Oo]ut* 