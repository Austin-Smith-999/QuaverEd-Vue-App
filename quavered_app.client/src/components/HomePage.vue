<template>
  <div class="d-flex align-items-center vh-100">
    <div class="mx-auto">
      <img alt="Q logo" src="./icons/Q_Icon.png" class="align-middle rotate" />
      <div class="fs-5 font-monospace text-center"> QuaverEd, Inc. </div>



      
    </div>
    <div v-if="post" class="content">
      <table>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="forecast in post" :key="forecast.date">
            <td>{{ forecast.date }}</td>
            <td>{{ forecast.temperatureC }}</td>
            <td>{{ forecast.temperatureF }}</td>
            <td>{{ forecast.summary }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<style>
 .rotate {
  animation: rotation 3s linear infinite;
}
  @keyframes rotation {
    from {
      transform: rotate3d(0, 1, 0, 0deg);
    }

    to {
      transform: rotate3d(0, 1, 0, 360deg);
    }
  }
</style>
<script lang="js">
  import { defineComponent } from 'vue';

  export default defineComponent({
    data() {
      return {
        loading: false,
        post: null
      };
    },
    created() {
      // fetch the data when the view is created and the data is
      // already being observed
      this.fetchData();
    },
    watch: {
      // call again the method if the route changes
      '$route': 'fetchData'
    },
    methods: {
      fetchData() {
        this.post = null;
        this.loading = true;

        fetch('GitHubRepos')
          .then(r => r.json())
          .then(json => {
            this.post = json;
            this.loading = false;
            return;
          });
      }
    },
  });
</script> 






<!-- 
<template>
  <div class="d-flex align-items-center vh-100">
    <div class="mx-auto">
      <img alt="Q logo" src="./icons/Q_Icon.png" class="align-middle rotate" />
      <div class="fs-5 font-monospace text-center"> QuaverEd, Inc. </div>
    </div>
    <div v-if="repositories.length > 0" class="content">
      <table>
        <thead>
          <tr>
            <th>Repository Name</th>
            <th>Description</th>
            <th>Stars</th>
            <th>Owner</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="repo in repositories" :key="repo.id">
            <td>{{ repo.name }}</td>
            <td>{{ repo.description }}</td>
            <td>{{ repo.stars }}</td>
            <td>{{ repo.ownerUsername }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<style>
.rotate {
  animation: rotation 3s linear infinite;
}
@keyframes rotation {
  from {
    transform: rotate3d(0, 1, 0, 0deg);
  }
  to {
    transform: rotate3d(0, 1, 0, 360deg);
  }
}
</style>


<script>
import axios from "axios";

export default {
  data() {
    return {
      repositories: []
    };
  },
  methods: {
    async fetchRepositories() {
      try {
        const response = await axios.get("http://localhost:5001/home/repositories");
        this.repositories = response.data;
      } catch (error) {
        console.error("Error fetching repositories:", error);
      }
    }
  },
  mounted() {
    this.fetchRepositories();
  }
};
</script> -->

<!-- <script>
import axios from "axios";

export default {
  data() {
    return {
      loading: false,
      repositories: [] // Renamed to better reflect the data being fetched
    };
  },
  created() {
    // Fetch repositories when the view is created
    this.fetchRepositories();
  },
  watch: {
    // Automatically fetch repositories if the route changes
    "$route": "fetchRepositories"
  },
  methods: {
    async fetchRepositories() {
      this.loading = true; // Indicate loading
      try {
        // const response = await axios.get("http://localhost:5001/home/repositories"); // original
        const response = await axios.get("http://localhost:5278/home/repositories");
        this.repositories = response.data; // Store the fetched data
        this.loading = false;
      } catch (error) {
        console.error("Error fetching repositories:", error); // Log any errors
        this.loading = false;
      }
    }
  }
};
</script> -->
