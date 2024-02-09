Out.txt:main.exe
	mono $< > $@

main.exe:main.cs
	mcs main.cs

clean:
	rm -f main.exe Out.txt

