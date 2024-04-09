
out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs roots.dll
	mcs -target:exe -out:main.exe -reference:roots.dll main.cs

roots.dll:roots.cs RK.cs matrix.cs vector.cs qrgs.cs genlist.cs
	mcs -target:library -out:roots.dll roots.cs RK.cs matrix.cs vector.cs qrgs.cs genlist.cs

clean:
	$(RM) *.exe *.dll [Oo]ut*