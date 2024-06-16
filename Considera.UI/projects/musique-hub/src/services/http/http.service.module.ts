import {NgModule} from "@angular/core";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "./http.service";
import {HttpMusiqueService} from "./http-musique/http-musique.service";

@NgModule({
  declarations: [],
  imports: [HttpClientModule],
  exports: [],
  providers: [
    HttpService,
    HttpMusiqueService
  ]
})
export class HttpServiceModule {}
