#r "System.Data"
#r "System.Data.Linq"
#r "FSharp.Data.TypeProviders"

open System.Linq
open Microsoft.FSharp.Data.TypeProviders
    
type SqlConnection = 
    SqlDataConnection<ConnectionString = @"Data Source=.\sql2008r2;Initial Catalog=chinook;Integrated Security=True">

let db = SqlConnection.GetDataContext()

let table = 
    query { for r in db.Artist do
            select r }

let artists =
    table
    |> Seq.iter (fun a -> printf "[%d] %s\n" a.ArtistId a.Name)


// --------------------------------------------------------------
// Repository

type ChinookRepository () =
    member x.GetArtists () =
        use context = SqlConnection.GetDataContext()
        query { for g in context.Artist do
                select g }
        |> Seq.toList       

let artists = 
    ChinookRepository().GetArtists()
    |> Seq.iter (fun a -> printf "[%d] %s\n" a.ArtistId a.Name)
