Out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs minimize.dll
	mcs -target:exe -out:main.exe -reference:minimize.dll main.cs

minimize.dll: minimize.cs ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs
	mcs -target:library -out:minimize.dll $^

clean:
	$(RM) *.exe *.dll *.txt

