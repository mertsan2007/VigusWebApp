# VigusWebApp
gerçek olmayan bilgisayar parçaları üreten bir firmanın websitesi. sitenin amacı bu firmanın ürünleri hakkında bilgi sahibi olma ve indirilebilir içeriklerini görüntülemedir. Bu firma birden fazla ürün (gpu) üretir. GPU(ekran kartı)'ların belirli özellikleri vardır. Bellek kapasitesi, Tükettiği güç ve sahip olduğu gpu ailesi(c,b,a serisi) bunlardan bazılarıdır. Her GPU'nun sahip olduğu driver sürümleri birden fazla olabilir ayrıca her driver sürümünün birden fazla GPU'su olabilir. bu bir many to many ilişkisine örnektir.

Home/support.cshtml bir gpu bulup o gpu'nun sahip olduğu driver sürümlerini ve firmanın ürünlerinde kullanduığı teknolojileri görüntülemek içindir.
Home/index.cshtml firmanın tüm ürünlerini en son eklenene göre sıralar. Bu sıralama ayrıca bir partial view örneğidir ve Home/Products.cshtml de aynı sıralamayı görmek mümkündür.

Geri kalan viewlerin çoğu CRUD işlemleri içindir.

# not:
uygulamayı çalıştırmadan önce package manager consola update-database yazınız.
uygulamanın tasarımının çoğu benim değildir

# ekran görüntüleri
![alt text](https://raw.githubusercontent.com/mertsan2007/VigusWebApp/master/fotograflar/1.jpeg)
![alt text](https://raw.githubusercontent.com/mertsan2007/VigusWebApp/master/fotograflar/2.jpeg)
![alt text](https://raw.githubusercontent.com/mertsan2007/VigusWebApp/master/fotograflar/3.jpeg)
