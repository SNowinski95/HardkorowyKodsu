Kilka słów komentarza:
Projekt nie zawiera testów jednostkowy z powodów iż nie widzę tam logiki biznesowej, która by tego wymagała, z tego też powodu nie jest dodana również żadna warstwa serwisowa.
Z powodu charakteru zadania nie zastosowałem frameworka bazodanowego (EF core/nHibernate) a jedynie maper bazodanowy (dapper).
Logowanie zostało zaimplementowane jedynie po stronie API, prawdopodobnie dobrym pomysłem byłoby dodanie go również po stronie klienta, jednak nie jest to tak samo istotne jak w przypadku API, które może zostać za hostowane w wielu instancjach, co ułtwia diagnozowanie błędu.
Autentykacja została uproszczona do pojedynczego tokena weryfikowanego w middleware-że w celu zabezpieczenia API przed niepożądanym dostępem, jednak w przypadku bardziej skomplikowanym (logowanie, wygasanie tokenu) zastosował bym JWT.
W celu uproszczenia aplikacji, token przetrzymywany jest w pliku konfiguracyjnym jednak jest to zła praktyka dużo lepsze jest używanie serwisów do tego przeznaczonych, a przynajmniej użycie w zaszyfrowanej formie przez zewnętrzne narzędzie.
appsetings.json powinno być w gitignor jednak na potrzeby ułatwienia odpalenia aplikacji zostawiłem plik w repozytorium.

