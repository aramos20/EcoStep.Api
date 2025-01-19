using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
namespace EcoStep.Infrastructure.Extensions.Firebase;
public static class FirebaseAdminHelper
{
    public static void InitializerFirebase(string serviceAccountPath)
    {
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile(serviceAccountPath)
        });
    }
}