Out.txt:main.exe
	mono $< > $@

main.exe:main.cs
	mcs -target:exe -out:main.exe

clean:
	$(RM) main.exe Out.txt

