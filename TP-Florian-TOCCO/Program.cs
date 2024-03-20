

using TP_Florian_TOCCO;


Repository.LoadAll();       // Charge tous les véhicules depuis le JSON


while (true)
{

    switch (MenuManager.Start())
    {
        case 1:         // Créer un vehicule
            Repository.CreateVehicule();
            break;

        case 2:         // Voir tous les vehicules

            Display.DisplayAllVehicules();
            Display.DisplayContinueMessage();
            break;

        case 3:     // Filtrer les vehicules
            MenuManager.FilterBy();
            
            break;

        case 4:         // Trier les véhicules
            MenuManager.SortBy();
            
            break;

        case 5:             // Rechercher un véhicule
            MenuManager.Search();
            break;

        case 6:     // Supprimer un vehicule
            Repository.Delete();
            break;
            
        case 7:         // Sauvegarder
            Repository.Save();
            break;

        case 8:         // Mettre a jour un vehicule
            MenuManager.UpdateVehicle();
            
            break;

        default:
            Display.DisplayWrongChoiceMessage();
            break;
    }
}