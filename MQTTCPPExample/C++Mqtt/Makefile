all: cmqtt

cmqtt: 
	g++ -o cmqtt -Wall -std=c++20 C++Mqtt.cpp -I ../Dependencies/libhv/include/hv -I ../Dependencies/gzip/include/ -I ../Dependencies/zlib/include/ ../Dependencies/libhv/lib/Debug/libhv.a ../Dependencies/zlib/lib/libz.a

clean:
	rm cmqtt
