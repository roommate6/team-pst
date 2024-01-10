import { Component, OnInit } from '@angular/core';
import { AppStateTracker } from 'src/app/classes/appStateTracker';
import { User } from 'src/app/interfaces/user.interface';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit{
  loggedUser: User | undefined;

  constructor() {}

  ngOnInit(): void {
    this.loggedUser = AppStateTracker.instance.loggedUser;
  }

}
