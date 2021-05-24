import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InstagramChatComponent } from './instagram-chat/instagram-chat.component';


const routes: Routes = [
  {
    path:'inchat',component:InstagramChatComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InstagramRoutingModule { }
