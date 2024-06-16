import {NgModule} from "@angular/core";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "./http.service";
import {HttpGamesService} from "./http-games/http-games.service";

@NgModule({
  declarations: [],
  imports: [HttpClientModule],
  exports: [],
  providers: [
    HttpService,
    HttpGamesService
  ]
})
export class HttpServiceModule {}
