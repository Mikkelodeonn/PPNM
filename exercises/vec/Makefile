Out.txt:main.exe
	mono $< > $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean: 
	$(RM) Out.txt main.exe


