BUILD_DIR = x64/linux
CD_BUILD_DIR = cd ${BUILD_DIR}

main: CppLibrary.so main.o
	${CD_BUILD_DIR}; $(CXX) -o main  main.cpp -L. -lCppLibrary

CppLibrary.so: CppLibrary.cpp
	${CD_BUILD_DIR}; $(CXX) -fPIC -c CppLibrary.cpp -o CppLibrary.o; $(CXX) -shared  -Wl,-soname,libCppLibrary.so -o libCppLibrary.so CppLibrary.o

all: prep main clean_prep

prep:
	mkdir -p ${BUILD_DIR};
	@cp *.h *.cpp ${BUILD_DIR}
	${CD_BUILD_DIR}; dos2unix *.h *.cpp

clean_prep:
	${CD_BUILD_DIR}; rm -f *.cpp *.h;

clean:
	${CD_BUILD_DIR}; rm -f *.o *.so *.cpp *.h main;
	rmdir ${BUILD_DIR}

