using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

// Projenizin Ad Alanı (Namespace)
namespace CeviriUygulamasi
{

    // ===================================================================
    // FORM SINIFI TANIMI
    // ===================================================================
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Formun ilk yüklendiğinde çalışacak metot (Load) olayına bağlanır.
            this.Load += new EventHandler(Form1_Load);
        }

        // ------------------------------------------------------------------
        // Form Yükleme Olayı: Dilleri ComboBox'lara yükler
        // ------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            // Dil kodları (Item1) ve kullanıcıya gösterilecek isimlerin (Item2) listesi
            var diller = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("tr", "Türkçe"),
                new Tuple<string, string>("en", "İngilizce"),
                new Tuple<string, string>("de", "Almanca"),
                new Tuple<string, string>("fr", "Fransızca"),
                new Tuple<string, string>("es", "İspanyolca"),
                new Tuple<string, string>("ar", "Arapça"),
                new Tuple<string, string>("ru", "Rusça"),
                // İhtiyacınız olan diğer dilleri buraya ekleyebilirsiniz.
            };

            // Kaynak Dil (cmbKaynakDil) ComboBox'ını Doldurma
            cmbKaynakDil.DataSource = new List<Tuple<string, string>>(diller);
            cmbKaynakDil.DisplayMember = "Item2"; // Görünecek değer
            cmbKaynakDil.ValueMember = "Item1";   // Kodda kullanılacak değer ("tr", "en" vb.)
            cmbKaynakDil.SelectedIndex = 0;       // Varsayılan: Türkçe

            // Hedef Dil (cmbHedefDil) ComboBox'ını Doldurma
            cmbHedefDil.DataSource = new List<Tuple<string, string>>(diller);
            cmbHedefDil.DisplayMember = "Item2";
            cmbHedefDil.ValueMember = "Item1";
            cmbHedefDil.SelectedIndex = 1; // Varsayılan: İngilizce
        }


        // ------------------------------------------------------------------
        // Çevir Butonu Olayı: API isteği gönderir ve sonucu alır
        // ------------------------------------------------------------------
        private async void btnCevir_Click(object sender, EventArgs e)
        {
            // Arayüzden gerekli verileri alma
            string kaynakMetin = txtKaynakMetin.Text.Trim();
            string kaynakDil = cmbKaynakDil.SelectedValue.ToString();
            string hedefDil = cmbHedefDil.SelectedValue.ToString();

            if (string.IsNullOrEmpty(kaynakMetin))
            {
                MessageBox.Show("Lütfen çevrilecek metni girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sonuç alanını temizle ve bekleme durumunu göster
            txtCeviriSonucu.Text = "Çevriliyor, lütfen bekleyin...";

            try
            {
                // 1. API İsteği URL'si Oluşturma
                // Metni URL'ye güvenli bir şekilde eklemek için dönüştür (URL Encoding)
                string encodedText = Uri.EscapeDataString(kaynakMetin);
                // MyMemory API URL formatı: q={metin}&langpair={kaynak}|{hedef}
                string url = $"https://api.mymemory.translated.net/get?q={encodedText}&langpair={kaynakDil}|{hedefDil}";

                // 2. HTTP İstemcisi Oluşturma ve İstek Gönderme
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // JSON yanıtını oku
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // 3. JSON Verisini C# Nesnesine Dönüştürme
                        MyMemoryResponse ceviriNesnesi = JsonConvert.DeserializeObject<MyMemoryResponse>(jsonResponse);

                        // 4. Çevrilmiş Metni Arayüze Yazma
                        if (ceviriNesnesi?.responseData?.translatedText != null)
                        {
                            txtCeviriSonucu.Text = ceviriNesnesi.responseData.translatedText;
                        }
                        else
                        {
                            txtCeviriSonucu.Text = "Çeviri yapılamadı. API yanıtı geçersiz veya eksik.";
                        }
                    }
                    else
                    {
                        // Başarısız HTTP yanıtı (404, 500 vb.)
                        MessageBox.Show($"API bağlantı hatası: HTTP Durum Kodu {response.StatusCode}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCeviriSonucu.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                // Genel hata yönetimi (Örn: İnternet bağlantısı yok)
                MessageBox.Show("Beklenmedik bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCeviriSonucu.Text = string.Empty;
            }
        }

        
    } // Form1 Sınıfı Sonu

    // ===================================================================
    // API MODEL SINIFLARI (VERİ TAŞIYICILARI)
    // ===================================================================

    // API yanıtının ana yapısını temsil eder
    public class MyMemoryResponse
    {
        public ResponseData responseData { get; set; }
        public string quotaFinished { get; set; }
        // public List<object> matches { get; set; } // Ek bilgi isterseniz bunu da ekleyebilirsiniz
    }

    // Çeviri sonucunu taşıyan iç yapıyı temsil eder
    public class ResponseData
    {
        public string translatedText { get; set; }
    }

} // Namespace Sonu