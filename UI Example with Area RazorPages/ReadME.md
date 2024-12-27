1. Scaffold Identity pages via VS UI or commandline.

2.Run following commands:
    [NOTE]: After the first five commands execute, make sure that you press Enter on the keyboard to execute the last command.
    dotnet tool install --global dotnet-aspnet-codegenerator
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools

3. Visit https://davidshimjs.github.io/qrcodejs/, and download qrcode zip file.
4. Extract it and copy qrcode.js out of it, and paste in wwwroot/lib.
5. Add this "<script src="~/lib/qrcode.js"></script>" line to _Layout.cshtml file.

6. Add following snippet to Areas/Identity/Pages/Account/Manage/EnableAuthenticator.cshtml.
<script>
    $(()=>{
        var qrcode = new QRCode(document.getElementById("qrCode"), {
            text: "@Html.Raw(Model.AuthenticatorUri)",
            width: 128,
            height: 128,
            colorDark : "#000000",
            colorLight : "#ffffff",
            correctLevel : QRCode.CorrectLevel.H
        });
    })
</script>