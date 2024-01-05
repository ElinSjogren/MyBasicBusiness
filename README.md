Följ med i CategoryCrudTest.cs => 

Setup har TestCategory av klassen Category som matas in i den mockade databasen _dbCon. Den används till olika crudl-operationer som testas i denna fil. 

Create 

Jag har två olika ActionResult för AddCategory: en som tar emot ett object och en som inte tar emot något alls. 

 Test: AddCategory_SchouldReturnToActionResult_WithCategory => 
skickar in ett Category-objekt i category-controllerns AddCategory-action method. Testet kollar så att det som returneras är en Redirection till sidan index i mappen Category. 

Test: AddCategory_SchouldReturnViewResult_WithNoCategory controllerar bara att sidan/viewen returneras. 

READ 

Test: Index_ReturnsViewResult_WithListOfCategory kollar så att listan som returneras från actionRsult har lika många rader som vår databas (här i detta test har vi bara en) 

Update 

Här har vi också två olika actionresult i controllen men som tar emot olika saker, den ena ett id och den andra hela objektet. 

Test: EditCategory_SchouldReturnAProductObj_WithId 

Controllern får in ett id och tar fram rätt objekt i databasen som sedan i sin tur skickas med till nästa view. I testet Jämför vi om id:t som skickas med är detsamma som det som vi får tillbaka. 

 

Delete 

Test: DeleteCategory_SchouldReturnViewResult_WithId 

Detta test är väldigt likt ovan nämnda. I Category-controllerns DElete metod  tas ett objekt fram med hjälp av att söka på id. När det har raderats returneras objektet som det gällde. I testet jämför vi om id:erna som vi skickat in med det id:t till objektet vi fick tillbaka. 

Testerna för Product och för Category är i princip detsamma. Det som skiljer är namnen på objekten och klasserna. 

För att köra applicationen behöver man bara logga in så kan man testa alla funktioner. Båda sidor för produkt och Kategori har samma funktioner. 

------------------------------------------------------------- 
Egna reflektioner  
Efter detta är dels att jag inte behöver förstå allt utan försöka att verkligen gå vidare. Jag fastnade flera gånger i en oändlig läsning i dokumentationen. Visst det är bra att lära sig nya saker men det tar väldigt mycket tid. 
 
Jag har också lärt mig att det tar mycket mer tid än vad man tror att göra ett sådant här projekt. Jag kände först att jag nog skulle kunna spara en del tid på att inte behöva lägga in så mycket tid på layout, stil och css. Man fick väldigt mycket gratis. Men det blev ändå väldigt ont om tid. 

 

Jag har verkligen fått lära mig att kollegor/klasskamrater gör en otrolig skillnad. Även om vi jobbar i olika projekt så har mina snälla klasskamrater funnits där varje dag. Jag tycker faktiskt att det är mycket smidigt att jobba på distans, då man kan dela skärm och se varandras arbeten. Istället för att följa med till någons skrivbord. 
 
Just nu behöver jag mest tänka igenom denna process, för det har varit mycket stressigt. En stor del i mitt sätt att lära mig nya saker är att göra det på ett roligt sätt. Stress är inte roligt. Det var inget fel på uppgiften, skulle jag säga. Utan mer att det var för kort tid för mig. Så En lärdom jag tar med mig är väl att inte ha ledigt på helgen utan även då sitta med skolarbete, hellre råka vara färdig någon dag innan än att ha detta sent en fredag kväll. Mer än så kan jag inte komma på.
