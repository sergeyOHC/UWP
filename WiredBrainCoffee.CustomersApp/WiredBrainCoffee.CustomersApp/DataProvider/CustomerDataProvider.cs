﻿using System.Collections.Generic;
using Windows.Storage;
using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using WiredBrainCoffee.CustomersApp.Model;
using Newtonsoft.Json;

namespace WiredBrainCoffee.CustomersApp.DataProvider
{
    public class CustomerDataProvider
    {
        private static readonly string _customersFileName = "customers.json";
        private static readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        public async Task<IEnumerable<Customer>> LoadCustomersAsync()
        {
            var storageFile = await _localFolder.TryGetItemAsync(_customersFileName) as StorageFile;
            List<Customer> customerList = null;

            if (storageFile == null)
            {
                customerList = new List<Customer>
                    {
                      new Customer{FirstName="Thomas",LastName="Huber",IsDeveloper=true},
                      new Customer{FirstName="Anna",LastName="Rockstar",IsDeveloper=true},
                      new Customer{FirstName="Julia",LastName="Master"},
                      new Customer{FirstName="Urs",LastName="Meier",IsDeveloper=true},
                      new Customer{FirstName="Sara",LastName="Ramone"},
                      new Customer{FirstName="Elsa",LastName="Queen", IsTester= true},
                      new Customer{FirstName="Alex",LastName="Baier"},
                    };
            }
            else
            {
                using (var stream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    using (var dataReader = new DataReader(stream))
                    {
                        await dataReader.LoadAsync((uint)stream.Size);
                        var json = dataReader.ReadString((uint)stream.Size);
                        customerList = JsonConvert.DeserializeObject<List<Customer>>(json);
                    }
                }
            }

            return customerList;
        }

        public async Task SaveCustomersAsync(IEnumerable<Customer> customers)
        {
            var storageFile = await _localFolder.CreateFileAsync(_customersFileName, CreationCollisionOption.ReplaceExisting);
            //path: C:\Users\john.patole\AppData\Local\Packages\81cf5b69-9d9a-443f-9d2a-ef882b81ba53_899brbe7kttgg\LocalState\customers.json
            using (var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var dataWriter = new DataWriter(stream))
                {
                    var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
                    dataWriter.WriteString(json);
                    await dataWriter.StoreAsync();
                }
            }
        }
    }
}

