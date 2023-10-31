# Hangfire Background Jobs

Cronjob'lar kendi veritabanlarına sahip olmalıdır.

Uygulamalarımız request bazlı çalışır fakat bazı durumlarda; her gün x saatte çalışan/iş yapan uygulamalar gibi..
Kullanıcı kayıt olduktan 10 dk sonra mail atılması gibi..
Yeni kayıt olmuş kişilere akşam saat X de promosyan kodu gönderelim gibi..
Doğum günü olan kullanıcılara şu kodları gönder vs...
Bu tür işlemleri Cronjob'larla hallederiz.

HangFire, .NET Core uygulamalarına özgü değildir.


// ---- DashBoard'a 
https://localhost:7272/hangfire ile erişebiliriz.


Panelde job's inceleyebilir veya tetikleyebiliriz. 
Tetiklenen her job rapor oluşturur. Hata oldu veya çalıştı gibi.. ve Jobs başlığı altında görüntülenebilir.
Jobs-> Enqueued'de kuyruğa alınan jobs görünür bunun sebebi server's kaynaklıdır. Server eklenemediyse ya da hata durumunda işlemleri kuyruğa alır.

