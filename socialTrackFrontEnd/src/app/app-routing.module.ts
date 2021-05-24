import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddnewUsersComponent } from './addnew-users/addnew-users.component';
import { LoginComponent } from './login/login.component';
import { DeshbordComponent } from './deshbord/deshbord.component';
import { MyProfileComponent } from './my-profile/my-profile.component';


const routes: Routes = [
  {
   path:'',component:LoginComponent 
  },
  {
    path:'Registerform',component:AddnewUsersComponent
  },
  {
    path:'whatsapp',loadChildren:()=>import('./whats-app/whats-app.module').then( w=>w.WhatsAppModule)
  },
  {
    path:'facebook',loadChildren:()=>import('./facebook/facebook.module').then(f=>f.FacebookModule)
  },
  {
    path:'instagram',loadChildren:()=>import('./instagram/instagram.module').then(a=>a.InstagramModule)
  },
  {
    path:'dashbord',component:DeshbordComponent
  },
  {
    path:'my-profile',component:MyProfileComponent
  },
  {
    path:'myadmin',loadChildren:()=>import('./admin/admin.module').then(a=>a.AdminModule)
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
