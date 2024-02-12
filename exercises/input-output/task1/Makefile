Out.txt:main.exe
	mono main.exe -numbers:1,2,3,4,5 > Out.txt

main.exe:main.cs
	mcs main.cs

clean:
	rm -f main.exe Out.txt

