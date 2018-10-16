# Viola
Viola Online Task Management App

## Nedir ?
Projelerinizi, görevlerinizi ve görevlere harcadığınız süreleri takip edebileceğiniz online task management uygulamasıdır. (OnlyOffice, Redbooth, Intervals vb gibi.)

## Neler Yapılabilir ?
- Şirket yönetimi
- Proje yönetimi
- Görev yönetimi
- Efor yönetimi
- Kullanıcı yönetimi
- (Burası daha sonra detaylandırılacaktır)

## Özellikleri
- Çoklu dil desteği (an itibariyle tam ingilizce desteği, kısmi türkçe desteği bulunuyor)
- Lokalizasyon (Tarih formatının ve saat timezone'unun kullanıcı bazlı değiştirilebilmesi)
- Yetkilendirme (External, User, Admin)
- Veritabanı ve kodlaması SaaS uygulama olarak tasarlandı. Fakat an itibariyle sadece tek bir şirket üzerinden çalışıyor. (Veri izolasyonu için her tabloda CompanyId isminde bir alan göreceksiniz)

## Kullanılan Teknolojiler - Third Party Kütüphaneler
Back-end
- C#
- Net Framework 4.6.1
- ASP.NET MVC 5
- Entity Framework 6 (Code First)
- AutoMapper 5
- Grid Mvc 2

Front-end
- Jquery 1.12
- Bootstrap 3
- Select2 4
- Moment.js 2
- Eonasdan Bootstrap Datetimepicker 4


## İleride Eklenecek Özellikler
- Görevlere yorum ekleyebilme özelliği.
- Görev üzerindeki değişikliklerin saklanması (history).
- Görev üzerinde değişiklik olduğunda ilgili kişilere email bildirim gönderilmesi.
- Türkçe dil desteğinin tamamlanması.
- Private proje seçeneği (Projeyi sadece oluşturan kişi görebilecek).
- Kullanıcı ekleme ve email bilgisi güncellendiğinde email'in geçerli olduğuna dair onay mekanizmanısının kurulması.
- Raporlama bölümünün yapılması. Time tracking vb temel raporların alınabilmesi. Ayrıca raporlar excel, csv, pdf'e dönüştürülebilmeli.
- SaaS uygulama haline getirilmesi.
