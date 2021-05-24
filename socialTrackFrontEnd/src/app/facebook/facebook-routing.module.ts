import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FacebookChatComponent } from './facebook-chat/facebook-chat.component';


const routes: Routes = [
  {
    path:'facbook',component:FacebookChatComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FacebookRoutingModule { }
