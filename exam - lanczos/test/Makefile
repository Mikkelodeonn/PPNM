Out.txt:main.exe
	mono $< 1> $@ 2> log.txt
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

lanczos.dll: ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs ../A/random.cs ../A/lanczos.cs EVD.cs
	mcs -target:library -out:lanczos.dll $^

main.exe:main.cs lanczos.dll 
	mcs -target:exe -out:main.exe -reference:lanczos.dll main.cs 

clean:
	$(RM) *.exe *.dll *.txt *.gpi [Oo]ut* 