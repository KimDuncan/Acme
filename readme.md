koden er skrevet i Microsoft Visual Studio Community 2019

Solution består af 5 projekter.

1. Acme.BusinessLayer som håndterer validering, opret og slet
2. Acme.DataLayer som bruger entityFramework til at opret og slet i databasen.
3. Acme.Web som er et ASP.CORE MVC projekt

4. Acme.Console som kan bruges til at oprette nye produkter og serialnumbers.
5. Acme.UnitTest som NUnit.Framework til at teste koden.

databasen er en lokal MSSQL(AcmeDB.mdf)
den består af 4 tabeller.
Draw som indeholder: email og serialnumber. 
Participant som indeholder: Id, Firstname, Lastname, Email og DateOfBirth
Product som indeholder: Id, Name, Description, SerialNumber og TypeId
Type som indeholder: Id, Name og Prefix

serialnumber generes baseret på Type.Prefix(4bogstaver) + 3tal + 2bogstaver + 3tal + 2bogstaver

DateOfBirth bruges til at validere alder på Participant samt, 
en kombination af email og DateOfBirth bruges til at validere Participant når de registre flere Serialnumbers

serialnumbers til at teste med kan findes i tabellen Product i databasen. 
eller i excel fil i roden af projektet

mvh
Kim Duncan-Bendix

