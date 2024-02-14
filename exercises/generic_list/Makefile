Out.txt:main.exe
	mono $< > Out.txt < input.txt

main.exe: main.cs genlist.dll
	mcs -out:$@ -target:exe -reference:genlist.dll main.cs

genlist.dll: genlist.cs
	mcs -out:$@ -target:library genlist.cs

clean:
	$(RM) *.dll *.exe log* [Oo]ut.txt
