import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WhatsaapChatComponent } from './whatsaap-chat/whatsaap-chat.component';
import { WhatsapprurlComponent } from './whatsapprurl/whatsapprurl.component';


const routes: Routes = [
  {
    path:'',component:WhatsaapChatComponent
  },
  {
    path:'url',component:WhatsapprurlComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WhatsAppRoutingModule { }
