Out.txt:main.exe
	mono $< 1> $@ 2> log.txt

lanczos.dll: matrix.cs vector.cs qrgs.cs random.cs lanczos.cs
	mcs -target:library -out:lanczos.dll $^

main.exe:main.cs lanczos.dll 
	mcs -target:exe -out:main.exe -reference:lanczos.dll main.cs 

clean:
	$(RM) *.exe *.dll *.txt [Oo]ut* 