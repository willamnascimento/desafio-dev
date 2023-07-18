import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CnabService } from './cnab.service';
import { environment } from 'src/environments/environment';
import { Cnab } from '../models/cnab';

describe('CnabService', () => {
  let service: CnabService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CnabService]
    });
    service = TestBed.inject(CnabService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call the API with the correct URL and parameters when getAll is called', () => {
    const dataImportacao = '2023-07-17';
    const expectedUrl = `${environment.URL_API}/api/v1/importacao/?dataImportacao=${dataImportacao}`;

    const mockResponse: Cnab[] = [
      {
        data_importacao: dataImportacao,
        tipo: '1',
        data: '2023-07-17',
        valor: 100.0,
        cpf: '12345678901',
        cartao: '1111222233334444',
        hora: '12:34:56',
        representante_loja: 'Representante Loja',
        loja: 'Loja'
      }
    ];

    service.getAll(dataImportacao).subscribe((cnabs: Cnab[]) => {
      expect(cnabs).toEqual(mockResponse);
    });

    const req = httpMock.expectOne(expectedUrl);
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });
});
