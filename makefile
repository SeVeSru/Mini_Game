CSHARP = mcs
MAIN_CLASS = Program.cs

all:
	$(CSHARP) $(OPT) $(MAIN_CLASS) $(PARTIAL_CLASSES)

clean:
	rm *.exe
