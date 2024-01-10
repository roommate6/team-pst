import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiConfigurations } from '../classes/apiConfigurations';
import { Observable, firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ImageService {
  constructor(private _http: HttpClient) {}

  async getImageById(id: number): Promise<string> {
    const appropriateUrl: string =
      ApiConfigurations.instance.imageGetUrl + `/${id}`;

    try {
      const result = await firstValueFrom(
        this._http.get(appropriateUrl, {
          responseType: 'arraybuffer',
          headers: new HttpHeaders({}),
        }),
        { defaultValue: null }
      );

      if (result === null) {
        throw new Error('Something happened with the image from the back end.');
      }

      const blob = new Blob([result], { type: 'image/jpg' });
      return URL.createObjectURL(blob);
    } catch (error) {
      console.error('Error fetching image:', error);
    }

    return '/assets/missing_image_placeholder.jpg';
  }
}
