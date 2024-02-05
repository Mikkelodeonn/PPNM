Out.txt:main.exe
	#mono main.exe > Out.txt
	mono $< > $@

main.exe:main.cs sfunc.dll
	mcs -target:exe -reference:sfunc.dll -out:main.exe main.cs

sfunc.dll:sfunc.cs
	mcs -target:library -out:sfunc.dll sfunc.cs

clean:
	$(RM)  sfunc.dll main.exe Out.txt

test: 
	echo $(RM)
