import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WhatsAppRoutingModule } from './whats-app-routing.module';
import { WhatsaapChatComponent } from './whatsaap-chat/whatsaap-chat.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { WhatsapprurlComponent } from './whatsapprurl/whatsapprurl.component';
import { ShellModule } from '../shell/shell.module';
import { HeaderComponent } from '../shell/header/header.component';
import { FooterComponent } from '../shell/footer/footer.component';
import { ModalModule } from 'ngx-modal';

@NgModule({
  declarations: [WhatsaapChatComponent, WhatsapprurlComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    WhatsAppRoutingModule,
    ShellModule,
    ModalModule
  ]
})
export class WhatsAppModule { }
