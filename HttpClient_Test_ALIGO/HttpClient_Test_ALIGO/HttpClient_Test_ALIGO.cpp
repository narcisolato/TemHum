#include <iostream>
#include <string>
#include <cstring>
#include <curl/curl.h>

using namespace std;

size_t callBackFunk(char* ptr, size_t size, size_t nmemb, string* stream)
{
	int realsize = size * nmemb;
	stream->append(ptr, realsize);
	return realsize;
}

string url_post_proc(const char url[], const char post_data[])
{
	CURL *curl;
	CURLcode res;
	curl = curl_easy_init();
	string chunk;

	if (curl)
	{
		curl_easy_setopt(curl, CURLOPT_URL, url);
		curl_easy_setopt(curl, CURLOPT_POST, 1);
		curl_easy_setopt(curl, CURLOPT_POSTFIELDS, post_data);
		curl_easy_setopt(curl, CURLOPT_POSTFIELDSIZE, strlen(post_data));
		curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, callBackFunk);
		curl_easy_setopt(curl, CURLOPT_WRITEDATA, (string*)&chunk);
		curl_easy_setopt(curl, CURLOPT_PROXY, "");
		res = curl_easy_perform(curl);
		curl_easy_cleanup(curl);
	}
	if (res != CURLE_OK) {
		cout << "curl error" << endl;
		exit(1);
	}

	return chunk;
}

string url_string(string key, string value)
{
	return key + "=" + value + "&";
}

int main()
{
	cerr << "*** 시작 ***\n";
	char url_target[] = "https://apis.aligo.in/send/";
	//char url_target[] = "http://192.168.0.54/Alarm/AlarmSearch"; //테스트
	
	string data;
	data = url_string("key", "xxxx");
	data += url_string("user_id", "xxxx");
	data += url_string("sender", "025114560");
	data += url_string("receiver", "01012345678,01011112222"); //전화번호
	data += url_string("destination", "01012345678|홍길동,01011112222|아무개"); //%고객명%에 들어갈 이름
	data += url_string("msg", "%고객명%님!안녕하세요.API TEST SEND");
	data += url_string("title", "API TEST 입니다");
	data += url_string("rdate", "20201207");
	data += url_string("rtime", "1406");
	data += url_string("testmode_yn", "Y");
	
	//char post_data[] = "user=jiro&password=123456";
	const char* post_data = data.c_str();
	
	string str_out = url_post_proc(url_target, post_data);
	
	cout << str_out << endl;
	cerr << "*** 종료 ***" << endl;
	return 0;
}
