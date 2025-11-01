# C# ve OpenCV ile Gerçek Zamanlı Yüz Tespiti Uygulaması

![C#](https://img.shields.io/badge/C%23-11.0-blue?logo=c-sharp&style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-8.0-purple?logo=.net&style=for-the-badge)
![OpenCV](https://img.shields.io/badge/OpenCV-OpenCvSharp4-green?logo=opencv&style=for-the-badge)
![Platform](https://img.shields.io/badge/Platform-Windows--Desktop-blue?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)

## 1. Proje Tanımı

Bu depo, Microsoft Visual Studio 2022 ortamında, C# Windows Forms ve **OpenCvSharp** kütüphanesi kullanılarak geliştirilmiş bir gerçek zamanlı yüz tespiti uygulamasını içermektedir.

Uygulama, yerel web kamerasından alınan video akışını işler ve OpenCV'nin önceden eğitilmiş Haar Cascade sınıflandırıcısını kullanarak tespit ettiği yüzleri, bir `PictureBox` bileşeni üzerinde canlı olarak bir dikdörtgen ile işaretler.

## 2. Temel Fonksiyonlar

* Web kamerasından canlı video akışının alınması ve işlenmesi.
* `OpenCvSharp` kütüphanesi aracılığıyla `Mat` nesnesinin `Bitmap`'e dönüştürülmesi.
* Önceden eğitilmiş `haarcascade_frontalface_default.xml` modeli kullanılarak yüz tespiti.
* Performans optimizasyonu için model yüklemesinin programın başlangıcına (Constructor) taşınması.
* Kararlı bir video akışı için `VideoCaptureAPIs.MSMF` (Microsoft Media Foundation) sürücüsünün kullanılması.

## 3. Teknoloji Yığını

* **IDE:** Visual Studio 2022
* **Platform:** .NET (Windows Forms Uygulaması)
* **Dil:** C#
* **Ana Kütüphane:** `OpenCvSharp4` (NuGet)
* **Gerekli Bağımlılıklar (NuGet):**
    * `OpenCvSharp4.runtime.win`
    * `OpenCvSharp4.Extensions`

## 4. Kurulum ve Yapılandırma

Projenin yerel makinede çalıştırılması için izlenmesi gereken adımlar:

1.  **Depoyu Klonlayın:**
    ```bash
    git clone https://[DEPO_ADRESINIZ_BURAYA_GELECEK]
    ```
    veya projeyi ZIP olarak indirin.

2.  **Projeyi Açın:**
    `OpenCv.sln` çözüm dosyasını Visual Studio 2022 ile açın.

3.  **NuGet Paketlerini Geri Yükleyin:**
    Visual Studio, projeyi açtığınızda paketleri otomatik olarak geri yüklemelidir. Eğer yüklemezse, "Çözüm Gezgini" (Solution Explorer) üzerinden projeye sağ tıklayın ve **"NuGet Paketlerini Yönet..."** seçeneğini seçin. "Gözat" (Browse) sekmesinden aşağıdaki **üç** paketin de yüklü olduğundan emin olun:
    * `OpenCvSharp4`
    * `OpenCvSharp4.runtime.win`
    * `OpenCvSharp4.Extensions`

4.  **Model Dosyasını Yapılandırın (Kritik Adım):**
    `haarcascade_frontalface_default.xml` model dosyasının, program derlendiğinde `.exe` dosyasının yanına kopyalanması gerekmektedir.
    * "Çözüm Gezgini" penceresinde `haarcascade_frontalface_default.xml` dosyasına tıklayın.
    * "Özellikler" (Properties) penceresine gidin.
    * **"Çıktı Dizinine Kopyala" (Copy to Output Directory)** özelliğini **"Daha yeniyse kopyala" (Copy if newer)** olarak değiştirin.

## 5. Kullanım Talimatları

1.  Uygulamayı Visual Studio üzerinden `F5` tuşuyla veya "Başlat" (Start) ▷ butonuyla çalıştırın.
2.  **Başlatma Gecikmesi:** Uygulamanın ilk açılışı, `haarcascade` modelinin belleğe yüklenmesi nedeniyle **birkaç saniye (diskinizin hızına bağlı olarak 5-10 saniye)** sürebilir. Bu, çalışma zamanı performansını (buton tepkimesini) optimize etmek için kasıtlı bir tasarım tercihidir.
3.  Uygulama arayüzü yüklendikten sonra **"Kamerayı Başlat"** butonuna tıklayın.
4.  Kameranın donanımsal olarak etkinleşmesi 1-2 saniye sürebilir.
5.  Video akışı `PictureBox` üzerinde başlayacak ve tespit edilen yüzler kırmızı bir dikdörtgen ile işaretlenecektir.
6.  Akışı durdurmak için **"Kamerayı Durdur"** butonuna tıklayın.

## 6. Lisans

Bu proje MIT Lisansı altında dağıtılmaktadır. Detaylı bilgi için `LICENSE` dosyasına bakınız.
