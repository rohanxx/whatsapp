import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { WhatsaapService } from './whatsaap.service';

@Component({
  selector: 'app-whatsaap-chat',
  templateUrl: './whatsaap-chat.component.html',
  styleUrls: ['./whatsaap-chat.component.css']
})
export class WhatsaapChatComponent implements OnInit {
  WhatsappForm: FormGroup;
  sendChatInfo: any;
  receivedChatInfo: any;
  constructor(private fw: FormBuilder, private whatsaapService: WhatsaapService, private route: Router) { }
  chats: any;
  chatInfo: any;
  receivedData: any;
  sentData: any;
  sendMessage: any;
  currentNumber: any;
  addContactForm:FormGroup;

  @ViewChild('msg',{static:true}) inputName;
  @ViewChild('addContact', {  static: true  }) addContact;
  
  ngOnInit() {
    this.createForm();
    this.loadchat();
    this.addContactForm = new FormGroup({
      contact_no: new FormControl(''),
      message: new FormControl('')
    });
  }

  createForm() {
    this.WhatsappForm = this.fw.group({
      message: [null]
    })
  };

  get formcontrols() { return this.WhatsappForm.controls; }

  Send(msg) {
    let messageElement = document.getElementById("msgBox");
    const { message } = this.WhatsappForm.value;
   
    let data = {
      phoneNumber: this.currentNumber,
      userMessage: msg,
    }
    this.whatsaapService.sendmessage(data).subscribe((x: any) => { debugger
      (<HTMLInputElement>document.getElementById("comment")).value = ' ';
      this.OpenChat(this.currentNumber);
      this.addContact.close();
      this.addContactForm.reset();
      this.loadchat();
    })
  };

  loadchat() {
    this.whatsaapService.getchat().subscribe((data: any) => {debugger
      if (data.statusCode = 200) {
        this.chats = data.responseData;
        console.info("listdata", this.chats);
      }
      else {
        console.info("no chats found")
      }
    })
  };

  OpenChat(ToNum) {
    this.currentNumber = ToNum;
    this.whatsaapService.getChatByNumber(ToNum).subscribe((x: any) => {debugger
      if (x.statusCode == 200) {
        this.chatInfo = x.responseData;
        console.info(this.chats);
      }
      else {
        this.chatInfo=null;  
      }
    })
  };

  selectedIndex;
  public setRow(_index: number) 
  {
    this.selectedIndex = _index;
  }

  addNumber() {
    this.currentNumber = this.addContactForm.value.contact_no;
    this.Send(this.addContactForm.value.message);
  }
}