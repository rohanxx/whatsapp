export class URLS{
    public static BaseUrl = "http://localhost:3000/";
}
export class Accounts_Controller {
    public static Login = "Accounts/Login";
 
    public static profile="Accounts/Profile?id=";
    public static editProfile="Accounts/EditProfile";
}
export class WhatsApp_Controller{
    public static getchat="WhatsApp/GetChats";
    public static getChatByNumber="WhatsApp/GetChatByNumber?number=";
    public static sendmessage="WhatsApp/SendWhatsaapMessage";
}
export class Contact_Controller{
    public static Contact="Contacts/AddNewContacts"
}
export class Register_Controller{
    public static NewRegistation="Register/RegisterNewUser"
    public static signin = "Register/Login";
}

export class Admin_Controller{
    public static GetAdmin="Admin/Getadmin";
    public static  NewAdmin="Admin/AddnewAdmin";
    public static UpdateAdmin="Admin/AdminUpdate";
    public static DeleteAdmin="Admin/DeleteAdmin?adm_ID=";
}