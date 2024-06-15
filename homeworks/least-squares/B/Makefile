CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

ls.dll: ../A/lslib.cs ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs ; $(MKLIB)
main.exe: main.cs ls.dll ; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*