import { Company } from './company';
import { Address } from './address';
export interface User {
  id: string;
  name: string;
  userName: string;
  email: string;
  phone: string;
  website: string;
  address: Address;
  company: Company;
}
