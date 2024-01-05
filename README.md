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
