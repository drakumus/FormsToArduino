int initialize();

String body = "";
int count = 0;
String str;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(13, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()) {
    str = Serial.readStringUntil('\n');
    if(str.length() > 0) {
      Serial.println(str);
      if(str[0] == '!') {
        initialize();
      } else if(str[0] == '?') {
        digitalWrite(13, LOW);
      } else {
        body += str + '\n';
        count++;
      }
      str = "";
    }
  }
}

int initialize() {
  int size = 0;
  digitalWrite(13, HIGH);
  
  if(str.length() > 1) {
    int i = 1;
    int size = str.substring(1,str.length()-1).toInt();
    Serial.print(size);
  }
  return size;
}