N=1e8
TIME = time --portability --append --output $@
Out.txt : main.exe Makefile
	>$@
	$(TIME) mono $< -terms:$N -threads:1 >>$@
	$(TIME) mono $< -terms:$N -threads:2 >>$@
	$(TIME) mono $< -terms:$N -threads:3 >>$@
	$(TIME) mono $< -terms:$N -threads:4 >>$@


main.exe: main.cs
	mcs main.cs

clean: 
	$(RM) main.exe Out.txt
