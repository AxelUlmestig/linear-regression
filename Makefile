SOURCE = main.cs src/*.cs  #csv_reader.cs linear_regression.cs
MAIN_EXE = main.exe
EXECUTABLE = linear_regression.exe

make:
	mcs -optimize -lib:packages/MathNet.Numerics.3.12.0/lib/net40/ -r:MathNet.Numerics.dll $(SOURCE)
	mono ILRepack.exe -out:$(EXECUTABLE) $(MAIN_EXE) MathNet.Numerics.dll
	rm $(MAIN_EXE)

install:
	curl -L http://nuget.org/nuget.exe -o nuget.exe
	mono nuget.exe install MathNet.Numerics
	cp MathNet.Numerics.3.12.0/lib/net40/MathNet.Numerics.dll .
	rm -r MathNet.Numerics.3.12.0/
	rm -r TaskParallelLibrary.1.0.2856.0/
	mono nuget.exe install ILRepack
	cp ILRepack.2.0.10/tools/ILRepack.exe . 
	rm -r ILRepack.2.0.10/
