<script setup lang="ts">
import { ref, onMounted } from "vue";
import {toast} from "vue3-toastify";
import {ToShortDate} from "@/common/formatters";

type LegalContracts = {
  id: string,
  author: string,
  legalEntity: string,
  contract: string,
  createdAt: string,
  updatedAt: string
}[];

let legalContracts = ref({} as LegalContracts);

onMounted(() => {
  fetchData();
});

function fetchData() {
  legalContracts.value = {} as LegalContracts;

  fetch('legalcontracts', {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'X-Content-Type-Options': 'nosniff',
    }
  })
      .then(r => r.json())
      .then(json => {
        legalContracts.value = json as LegalContracts;
        return;
      });
}

async function deleteItem(id:string) :  Promise<void> {
  const response = await fetch('legalcontracts/'+id, {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
      'X-Content-Type-Options': 'nosniff',
    }
  });
  if (response.ok) {
    toast('Legal Contract deleted successfully', {
      type: 'success',
    });

    // We can reload teh data from the server or manipulate the array directly, in order to avoid a new fetch
    // as we want to keep the data in sync with the server we will fetch the data again
    // but keep the commented code for reference
    fetchData();
    // legalContracts.value?.splice(legalContracts.value?.findIndex((contract) => contract.id === id), 1);
  } else {
    toast('Failed to delete Legal Contract', {
      type: 'error',
    });
  }
}
</script>

<template>
    <h3>Legal Contracts</h3>
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Author</th>
          <th scope="col">Legal Entity</th>
          <th scope="col">Contract</th>
          <th scope="col">Created At</th>
          <th scope="col">Updated At</th>
          <th scope="col"></th>
          <th scope="col"></th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="contract in legalContracts" :key="contract.id">
          <td>{{ contract.author }}</td>
          <td>{{ contract.legalEntity }}</td>
          <td>{{ contract.contract }}</td>
          <td>{{ ToShortDate(contract.createdAt) }}</td>
          <td>{{ ToShortDate(contract.updatedAt) }}</td>
          <th scope="row">
            <router-link :to="{name: 'UpdateContracts', params: {id: contract.id}}" class="nav-link">
              <i class="bi-pencil pointer" />
            </router-link>
          </th>
          <th scope="row">
            <router-link :to="{name: 'ContractDetails', params: {id: contract.id}}" class="nav-link">
              <i class="bi-eye pointer" />
            </router-link>
          </th>
          <th scope="row">
            <i class="bi-trash pointer" @click="deleteItem(contract.id)"></i>
          </th>
        </tr>
      </tbody>
    </table>
</template>

<style scoped>
 .pointer {
   cursor: pointer;
 }
</style>