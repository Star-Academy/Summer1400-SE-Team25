import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchWordComponent } from './search-word/search-word.component';
import { AddDirComponent } from './add-dir/add-dir.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchWordComponent,
    AddDirComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
