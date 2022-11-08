#include <SoftwareSerial.h>
SoftwareSerial sim900(10, 11); // RX: 10, TX:11

#include <ArduinoJson.h>
StaticJsonBuffer<200> jsonBuffer; 
 

char deviceID[12] = "MYTEST56";
 
 
void setup()
{
  sim900.begin(19200);        // the GPRS baud rate
  Serial.begin(19200);
  Serial.println("Initializing..........");
  DynamicJsonBuffer jsonBuffer;
  delay(5000);
}
 
void loop()
{
 
 /********************GSM Communication Starts********************/
 
  if (sim900.available())
    Serial.write(sim900.read());
 
  sim900.println("AT");
  delay(3000);
 
  sim900.println("AT+SAPBR=3,1,\"Contype\",\"GPRS\"");
  delay(6000);
  ShowSerialData();
 
  sim900.println("AT+SAPBR=3,1,\"APN\",\"orange");//APN
  delay(6000);
  ShowSerialData();
 
  sim900.println("AT+SAPBR=1,1");
  delay(6000);
  ShowSerialData();
 
  sim900.println("AT+SAPBR=2,1");
  delay(6000);
  ShowSerialData();
 
  sim900.println("AT+HTTPINIT");
  delay(6000);
  ShowSerialData();
 
  sim900.println("AT+HTTPPARA=\"CID\",1");
  delay(6000);
  ShowSerialData();
 
  StaticJsonBuffer<200> jsonBuffer;
  JsonObject& object = jsonBuffer.createObject();
  
  object.set("deviceID",deviceID);
  
  object.printTo(Serial);
  Serial.println(" ");  
  String sendtoserver;
  object.prettyPrintTo(sendtoserver);
  delay(4000);
 
  sim900.println("AT+HTTPPARA=\"URL\",\"http://192.xxxxxxxxxxxxxxxxxxxxxxxx.php\""); //Server address
  delay(4000);
  ShowSerialData();
 
  sim900.println("AT+HTTPPARA=\"CONTENT\",\"application/json\"");
  delay(4000);
  ShowSerialData();
 
 
  sim900.println("AT+HTTPDATA=" + String(sendtoserver.length()) + ",100000");
  Serial.println(sendtoserver);
  delay(6000);
  ShowSerialData();
 
  sim900.println(sendtoserver);
  delay(6000);
  ShowSerialData;
 
  sim900.println("AT+HTTPACTION=1");
  delay(6000);
  ShowSerialData();
 
  sim900.println("AT+HTTPREAD");
  delay(6000);
  ShowSerialData();
 
  sim900.println("AT+HTTPTERM");
  delay(10000);
  ShowSerialData();
 
  /********************GSM Communication Stops********************/
 
}
 
 
void ShowSerialData()
{
  while (sim900.available() != 0)
    Serial.write(sim900.read());
  delay(1000);
 
}