import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  mobileQuery: MediaQueryList;

  fillerNav=[
    {name:"login",route:"login",icon:"account_circle"},
    {name:"activities",route:"activities",icon:"note_alt"},
    {name:"authors",route:"authors",icon:"recent_actors"},
    {name:"books",route:"books",icon:"library_books"},
    {name:"add-books",route:"home",icon:"bookmark_add"}

  ]

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, public users: UsersService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  shouldRun = true;

  ngOnInit(): void {
  }

}

